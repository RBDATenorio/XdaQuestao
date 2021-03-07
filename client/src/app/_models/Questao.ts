import { Caderno } from "./Caderno";
import { Comentario } from "./Comentario";

export interface Questao {
    questaoId: number;  
    banca: string;  
    orgao: string;  
    disciplina: string;  
    assunto: string;  
    ano: string;  
    enunciado: string;  
    comentarioProfessor: string;  
    alternativaA: string;  
    alternativaB: string;  
    alternativaC: string;  
    alternativaD: string;  
    alternativaE: string;  
    resposta: string;  
    comentarios: Comentario[];
    cadernoQuestaos: Caderno[];
}
