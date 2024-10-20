import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})

export class RelatorioService {

  constructor( private httpClient: HttpClient ) { }

  getRelatorioSeguros(): any{

    //this.httpClient.get<any>('http://localhost:5077/CalculoDeSeguroDeVeiculos/EmiteRelatorio')
    this.httpClient.get<any>('/CalculoDeSeguroDeVeiculos/EmiteRelatorio')
    //this.httpClient.get<any>('https://localhost:7285/CalculoDeSeguroDeVeiculos/EmiteRelatorio')
    .subscribe(data => {
      console.log("CERTO!");
      return data;
    });
    
  }
}
