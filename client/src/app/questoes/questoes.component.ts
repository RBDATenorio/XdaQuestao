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
  editar: boolean = false;
  modoSalvar: string = 'post';
  questao!: Questao;
  acertou: boolean = false;
  registerForm!: FormGroup;
  modalRef!: BsModalRef;
  bodyDeletarQuestao = '';
  
  constructor(private questaoService: QuestaoService,
              private modalService: BsModalService,
              private fb: FormBuilder) { }

  ngOnInit(): void {
    this.getQuestoes();
    this.validation();
  }

  editarQuestao(questao: Questao) {
    this.modoSalvar = 'put';
    this.questao = Object.assign({}, questao);
    this.registerForm.patchValue(this.questao);
    this.editar = !this.editar;
    
  }

  adicionarQuestao() {
    this.registerForm.reset();
    this.modoSalvar = 'post';
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
      if(this.modoSalvar === 'post'){
        
        this.questao = Object.assign({}, this.registerForm.value);
        this.questaoService.postQuestao(this.questao).subscribe(
          (novaQuestao) => {
            this.openModal(template);
            this.getQuestoes();
          }, error => {
            console.log(error);
          }
        );
      } else {
          
          this.questao = Object.assign({id: this.questao.questaoId}, this.registerForm.value);
//          console.log(this.questao);
          this.questaoService.putQuestao(this.questao).subscribe(
            () => {
              this.getQuestoes();
              this.openModal(template);
            }, error => {
              console.log(error);
            }
          );
      }

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

  excluirQuestao(questao: Questao, template: any) {
    this.openModal(template);
    this.questao = questao;
    this.bodyDeletarQuestao = `Tem certeza que deseja excluir o Código: ${questao.questaoId}`;
  }
  
  confirmeDelete(template: any) {
    this.questaoService.deleteQuestao(this.questao.questaoId).subscribe(
      () => {
          template.hide();
          this.getQuestoes();
        }, error => {
          console.log(error);
        }
    );
  }


}
