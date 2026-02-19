import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface UsoPlano {
  limite: number;
  utilizadas: number;
  percentual: number;
  atingiuLimite: boolean;
  plano: string;
  restantes: number;

}

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  private readonly baseUrl = 'http://localhost:5143/api/usuarios';

  constructor(private http: HttpClient) {}

  getUsoPlano(usuarioId: string): Observable<UsoPlano> {
    return this.http.get<UsoPlano>(
      `${this.baseUrl}/uso-plano`,
      { params: { usuarioId } }
    );
  }
}