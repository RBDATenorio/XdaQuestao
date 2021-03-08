import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Questao } from '../_models/Questao';
import { QuestaoService } from '../_services/questao.service';

@Component({
  selector: 'app-questoes',
  templateUrl: './questoes.component.html',
  styleUrls: ['./questoes.component.css']
})
export class QuestoesComponent implements OnInit {

  questoes!: Questao[];
  pag: number = 1;
  contador: number = 1;
  totQuestoes!: number;
  adicionar: boolean = false;
  questao!: Questao;
  acertou: boolean = false;
  registerForm!: FormGroup;
  modalRef!: BsModalRef;
  
  constructor(private questaoService: QuestaoService,
              private modalService: BsModalService,
              private fb: FormBuilder) { }

  ngOnInit(): void {
    this.getQuestoes();
    this.validation();
  }

  adicionarQuestao() {
    this.adicionar = !this.adicionar;
  }

  validation() {
    this.registerForm = this.fb.group({
      banca: ['', [Validators.required, Validators.minLength(3)]],
      orgao: ['', Validators.required],
      disciplina: ['', Validators.required],
      assunto: ['', Validators.required],
      ano: ['', [Validators.required, Validators.maxLength(4), Validators.minLength(4)]],
      enunciado: ['', Validators.required],
      alternativaA: ['', ],
      alternativaB: ['', ],
      alternativaC: ['', ],
      alternativaD: ['', ],
      alternativaE: ['', ],
      resposta: ['', [Validators.required, Validators.maxLength(1)]]
    });
  }

  salvarAlteracao(template: TemplateRef<any>) {
    if(this.registerForm.valid){
      this.questao = Object.assign({}, this.registerForm.value);
      this.questaoService.postQuestao(this.questao).subscribe(
        (novaQuestao) => {
          this.openModal(template);
          this.getQuestoes();
        }, error => {
          console.log(error);
        }
      );
    }
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }
  
  getQuestoes() {
    this.questaoService.getAllQuestao().subscribe(
      ( _questaos: Questao[]) => { 
        this.questoes = _questaos,
        this.totQuestoes = this.questoes.length
      },
      
      error => {
        console.log(error);
      }
    )
  }


}
