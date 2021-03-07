import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-questao-header',
  templateUrl: './questao-header.component.html',
  styleUrls: ['./questao-header.component.css']
})
export class QuestaoHeaderComponent implements OnInit {

  @Input() numDaQuestao!: number;
  @Input() totalQuestoes!: number;
  @Input() titulo!: any;
  comentarioProfessor: boolean = false;
  comentarioAlunos: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

  mostrarComentarioProfessor () {
    if (this.comentarioAlunos){
      this.mostrarComentarioAlunos();
    }
    this.comentarioProfessor = !this.comentarioProfessor;
  }

  mostrarComentarioAlunos () {
    if (this.comentarioProfessor){
      this.mostrarComentarioProfessor();
    }
    this.comentarioAlunos = !this.comentarioAlunos;
  }

}
