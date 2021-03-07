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

  constructor() { }

  ngOnInit(): void {
  }

}
