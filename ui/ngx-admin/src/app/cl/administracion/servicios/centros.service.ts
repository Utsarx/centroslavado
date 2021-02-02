import { Empleado } from './../modelos/empleado';
import { CentroLavado } from './../modelos/centro-lavado';
import { environment } from './../../../../environments/environment';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

export const EmptyId: string = '00000000-0000-0000-0000-000000000000';

@Injectable({
  providedIn: 'root'
})
export class CentrosService {

  constructor(private http: HttpClient) {}


  // API de centros de lavado 
  // ---------------------------------------------------------------------------
  // ---------------------------------------------------------------------------
  private getApiCentrosLavado(): string {
    return `${environment.apiUrl}/api/centrosLavado`;
  }

  public GetCentrosLavado(): Observable<CentroLavado[]> {
    console.log(this.getApiCentrosLavado());
    return this.http.get<CentroLavado[]>(this.getApiCentrosLavado());
  }

  public GetCentroLavado(id: string): Observable<CentroLavado> {
    return this.http.get<CentroLavado>(this.getApiCentrosLavado() + '/' + id);
  }

  public PostCentroLavado(centro: CentroLavado): Observable<string> {
    const headers = new HttpHeaders()
      .set('content-type', 'application/json');
    return this.http.post<string>(this.getApiCentrosLavado(), centro, { 'headers': headers });
  }

  public PutCentroLavado(id: string, centro: CentroLavado): Observable<any> {
    const headers = new HttpHeaders()
      .set('content-type', 'application/json');
    return this.http.put<any>(this.getApiCentrosLavado() + `/${id}` , centro, { 'headers': headers });
  }

  public DelCentroLavado(id: string): Observable<string> {
    const headers = new HttpHeaders()
      .set('content-type', 'application/json');
    return this.http.delete<any>(this.getApiCentrosLavado() + `/${id}`, { 'headers': headers });
  }


  // API de Empleados
  // ---------------------------------------------------------------------------
  // ---------------------------------------------------------------------------
  private getApiEmpleado(): string {
    return `${environment.apiUrl}/api/empleados`;
  }

  public GetEmpleados(id: string): Observable<Empleado[]> {
    console.log(this.getApiCentrosLavado());
    return this.http.get<Empleado[]>(this.getApiEmpleado() + '/centro/' + id );
  }

  public GetEmpleado(id: string): Observable<Empleado> {
    return this.http.get<Empleado>(this.getApiEmpleado() + '/' + id);
  }

  public PostEmpleado(empleado: Empleado): Observable<string> {
    const headers = new HttpHeaders()
      .set('content-type', 'application/json');
    return this.http.post<string>(this.getApiEmpleado(), empleado, { 'headers': headers });
  }

  public PutEmpleado(id: string, empleado: CentroLavado): Observable<any> {
    const headers = new HttpHeaders()
      .set('content-type', 'application/json');
    return this.http.put<any>(this.getApiEmpleado() + `/${id}` , empleado, { 'headers': headers });
  }

  public DelEmpleado(id: string): Observable<string> {
    const headers = new HttpHeaders()
      .set('content-type', 'application/json');
    return this.http.delete<any>(this.getApiEmpleado() + `/${id}`, { 'headers': headers });
  }

}
