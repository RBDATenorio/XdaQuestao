import { Component, OnInit } from '@angular/core';
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

  constructor(private questaoService: QuestaoService) { }

  ngOnInit(): void {
    this.getQuestoes();
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
