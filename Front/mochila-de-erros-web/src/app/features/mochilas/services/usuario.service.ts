import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface UsoPlanoDto {
  limite: number;
  utilizadas: number;
  restantes: number;
  percentual: number;
  atingiuLimite: boolean;
}

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  private readonly baseUrl = 'http://localhost:5143/api/usuarios';

  constructor(private http: HttpClient) {}

  getUsoPlano(usuarioId: string): Observable<UsoPlanoDto> {
    return this.http.get<UsoPlanoDto>(
      `${this.baseUrl}/uso-plano`,
      { params: { usuarioId } }
    );
  }
}
