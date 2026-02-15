export interface MochilaCard {
    id: string;
    nome: string;
    descricao?: string;
    cor: string;
    tags: string[];

    totalQuestoes: number;
    pendentes: number;
    dominadas: number;

    periodoRevisao: string;
    bloqueada: boolean;
}