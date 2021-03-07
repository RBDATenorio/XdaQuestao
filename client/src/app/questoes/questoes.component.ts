import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-questoes',
  templateUrl: './questoes.component.html',
  styleUrls: ['./questoes.component.css']
})
export class QuestoesComponent implements OnInit {

  questoes: any = [];
  pag: number = 1;
  contador: number = 1;
  totQuestoes!: number;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getQuestoes();
  }

  getQuestoes() {
    this.http.get('http://localhost:5000/api/values').subscribe(
      response => { 
        this.questoes = response,
        this.totQuestoes = this.questoes.length
      },
      
      error => {
        console.log(error);
      }
    )
  }

}
