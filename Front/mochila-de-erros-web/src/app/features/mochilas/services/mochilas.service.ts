import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MochilaCard } from '../models/mochilas-card.model';


@Injectable({providedIn: 'root'})
export class MochilasService {
    private api = 'http://localhost:5143/api/mochilas';

    constructor(private http: HttpClient) { }

    getCards(userId: string): Observable<MochilaCard[]> {
        return this.http.get<MochilaCard[]>(
            `${this.api}/cards`,
            {
                params: { userId }
            }
        );
    }
  
}