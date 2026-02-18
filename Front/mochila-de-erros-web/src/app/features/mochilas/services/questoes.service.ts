import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { QuestaoCardModel } from '../models/questao-card.model';

@Injectable({ providedIn: 'root' })
export class QuestoesService {
    private apiUrl = 'http://localhost:5143/api';

    constructor(private http: HttpClient) {}

    getCards(mochilaId: string, userId: string): Observable<QuestaoCardModel[]> {
        return this.http.get<QuestaoCardModel[]>(
            `${this.apiUrl}/mochilas/${mochilaId}/questoes/cards`,
            { params: { userId } }
        );
    }
}