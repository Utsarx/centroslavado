import { Tractor } from './../modelos/tractor';
import { Chofer } from './../modelos/chofer';
import { environment } from './../../../../environments/environment';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EmpresaTransporte } from '../modelos/empresa-trasnporte';
import { Caja } from '../modelos/caja';

export const EmptyId: string = '00000000-0000-0000-0000-000000000000';

@Injectable({
  providedIn: 'root'
})
export class EmpresasService {

  constructor(private http: HttpClient) {}


  // API de empresas
  // ---------------------------------------------------------------------------
  // ---------------------------------------------------------------------------
  private getApiEmpresas(): string {
    return `${environment.apiUrl}/api/empresas`;
  }

  public GetEmpresas(): Observable<EmpresaTransporte[]> {
    console.log(this.getApiEmpresas());
    return this.http.get<EmpresaTransporte[]>(this.getApiEmpresas());
  }

  public GetEmpresa(id: string): Observable<EmpresaTransporte> {
    return this.http.get<EmpresaTransporte>(this.getApiEmpresas() + '/' + id);
  }

  public PostEmpresa(empresa: EmpresaTransporte): Observable<string> {
    const headers = new HttpHeaders()
      .set('content-type', 'application/json');
    return this.http.post<string>(this.getApiEmpresas(), empresa, { 'headers': headers });
  }

  public PutEmpresa(id: string, empresa: EmpresaTransporte): Observable<any> {
    const headers = new HttpHeaders()
      .set('content-type', 'application/json');
    return this.http.put<any>(this.getApiEmpresas() + `/${id}` , empresa, { 'headers': headers });
  }

  public DelEmpresa(id: string): Observable<string> {
    const headers = new HttpHeaders()
      .set('content-type', 'application/json');
    return this.http.delete<any>(this.getApiEmpresas() + `/${id}`, { 'headers': headers });
  }


  // API de choferers
  // ---------------------------------------------------------------------------
  // ---------------------------------------------------------------------------
  private getApiChofer(): string {
    return `${environment.apiUrl}/api/choferes`;
  }

  public GetChoferes(id: string): Observable<Chofer[]> {
    console.log(this.getApiEmpresas());
    return this.http.get<Chofer[]>(this.getApiChofer() + '/empresa/' + id );
  }

  public GetChofer(id: string): Observable<Chofer> {
    return this.http.get<Chofer>(this.getApiChofer() + '/' + id);
  }

  public PostChofer(chofer: Chofer): Observable<string> {
    const headers = new HttpHeaders()
      .set('content-type', 'application/json');
    return this.http.post<string>(this.getApiChofer(), chofer, { 'headers': headers });
  }

  public PutChofer(id: string, chofer: EmpresaTransporte): Observable<any> {
    const headers = new HttpHeaders()
      .set('content-type', 'application/json');
    return this.http.put<any>(this.getApiChofer() + `/${id}` , chofer, { 'headers': headers });
  }

  public DelChofer(id: string): Observable<string> {
    const headers = new HttpHeaders()
      .set('content-type', 'application/json');
    return this.http.delete<any>(this.getApiChofer() + `/${id}`, { 'headers': headers });
  }


  // API de Tractores
   // ---------------------------------------------------------------------------
  // ---------------------------------------------------------------------------
  private getApiTractores(): string {
    return `${environment.apiUrl}/api/tractores`;
  }

  public GetTractores(id: string): Observable<Tractor[]> {
    return this.http.get<Tractor[]>(this.getApiTractores() + '/empresa/' + id );
  }

  public GetTractor(id: string): Observable<Tractor> {
    return this.http.get<Tractor>(this.getApiTractores() + '/' + id);
  }

  public PostTractor(tractor: Tractor): Observable<string> {
    const headers = new HttpHeaders()
      .set('content-type', 'application/json');
    return this.http.post<string>(this.getApiTractores(), tractor, { 'headers': headers });
  }

  public PutTractor(id: string, tractor: EmpresaTransporte): Observable<any> {
    const headers = new HttpHeaders()
      .set('content-type', 'application/json');
    return this.http.put<any>(this.getApiTractores() + `/${id}` , tractor, { 'headers': headers });
  }

  public DelTractor(id: string): Observable<string> {
    const headers = new HttpHeaders()
      .set('content-type', 'application/json');
    return this.http.delete<any>(this.getApiTractores() + `/${id}`, { 'headers': headers });
  }



  // API de Cajas
   // ---------------------------------------------------------------------------
  // ---------------------------------------------------------------------------
  private getApiCajas(): string {
    return `${environment.apiUrl}/api/cajas`;
  }

  public GetCajas(id: string): Observable<Caja[]> {
    return this.http.get<Caja[]>(this.getApiCajas() + '/empresa/' + id );
  }

  public GetCaja(id: string): Observable<Caja> {
    return this.http.get<Caja>(this.getApiCajas() + '/' + id);
  }

  public PostCaja(Caja: Caja): Observable<string> {
    const headers = new HttpHeaders()
      .set('content-type', 'application/json');
    return this.http.post<string>(this.getApiCajas(), Caja, { 'headers': headers });
  }

  public PutCaja(id: string, tractor: EmpresaTransporte): Observable<any> {
    const headers = new HttpHeaders()
      .set('content-type', 'application/json');
    return this.http.put<any>(this.getApiCajas() + `/${id}` , tractor, { 'headers': headers });
  }

  public DelCaja(id: string): Observable<string> {
    const headers = new HttpHeaders()
      .set('content-type', 'application/json');
    return this.http.delete<any>(this.getApiCajas() + `/${id}`, { 'headers': headers });
  }

}
