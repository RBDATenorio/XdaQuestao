import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Questao } from '../_models/Questao';

@Injectable({
  providedIn: 'root'
})
export class QuestaoService {

  baseUrl = 'http://localhost:5000/api/questao';

  constructor(private http: HttpClient) { }

  getAllQuestao(): Observable<Questao[]> { 
    return this.http.get<Questao[]>(this.baseUrl);
  }

  getQuestaoByAno(ano: string): Observable<Questao[]> { 
    return this.http.get<Questao[]>(`${this.baseUrl}/getByAno/${ano}`);
  }  

  getQuestaoById(id: number): Observable<Questao> { 
    return this.http.get<Questao>(`${this.baseUrl}/${id}`);
  }

  postQuestao(questao: Questao) { 
    return this.http.post(this.baseUrl, questao);
  }
}
