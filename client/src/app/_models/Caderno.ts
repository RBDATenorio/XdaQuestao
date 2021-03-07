import { Questao } from "./Questao";

export interface Caderno {
    cadernoId: number; 
    usuarioId: number;
    cadernoQuestaos: Questao[];
}
