import { ConfiguracionVentaeCentroLavado } from './../modelos/configuracion-ventae-centrollavado';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
export const EmptyId: string = '00000000-0000-0000-0000-000000000000';

@Injectable({
  providedIn: 'root'
})
export class TerminalServices {

  constructor(private http: HttpClient) {}


//   API de empresas
//   ---------------------------------------------------------------------------
//   ---------------------------------------------------------------------------
  private getApiTerminal(): string {
    return `${environment.apiUrl}/api/puntoventa`;
  }

  public GetConfiguracion(): Observable<ConfiguracionVentaeCentroLavado[]> {
    console.log(this.getApiTerminal());
    return this.http.get<ConfiguracionVentaeCentroLavado[]>(this.getApiTerminal() + '/configuracion');
  }

//   public GetEmpresa(id: string): Observable<EmpresaTransporte> {
//     return this.http.get<EmpresaTransporte>(this.getApiEmpresas() + '/' + id);
//   }

//   public PostEmpresa(empresa: EmpresaTransporte): Observable<string> {
//     const headers = new HttpHeaders()
//       .set('content-type', 'application/json');
//     return this.http.post<string>(this.getApiEmpresas(), empresa, { 'headers': headers });
//   }

//   public PutEmpresa(id: string, empresa: EmpresaTransporte): Observable<any> {
//     const headers = new HttpHeaders()
//       .set('content-type', 'application/json');
//     return this.http.put<any>(this.getApiEmpresas() + `/${id}` , empresa, { 'headers': headers });
//   }

//   public DelEmpresa(id: string): Observable<string> {
//     const headers = new HttpHeaders()
//       .set('content-type', 'application/json');
//     return this.http.delete<any>(this.getApiEmpresas() + `/${id}`, { 'headers': headers });
//   }


}
