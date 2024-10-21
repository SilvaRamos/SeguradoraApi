import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})

export class RelatorioService {

  constructor( private httpClient: HttpClient ) { }

  getRelatorioSeguros(): any{

    this.httpClient.get<any>('/CalculoDeSeguroDeVeiculos/EmiteRelatorio')
    .subscribe(data => {
      console.log("DATA:" + data['mediaAritmeticaSeguros']);
      return data['mediaAritmeticaSeguros'];
    });
  }
}
