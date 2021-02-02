import { Servicio } from './../modelos/servicio';
import { environment } from '../../../../environments/environment';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Categoria } from '../modelos/categoria';
import { Precio } from '../modelos/precio';

export const EmptyId: string = '00000000-0000-0000-0000-000000000000';

@Injectable({
  providedIn: 'root'
})
export class CategoriasService {

  constructor(private http: HttpClient) {}


  // API de categorias
  // ---------------------------------------------------------------------------
  // ---------------------------------------------------------------------------
  private getApiCategorias(): string {
    return `${environment.apiUrl}/api/categorias`;
  }

  public GetCategorias(): Observable<Categoria[]> {
    console.log(this.getApiCategorias());
    return this.http.get<Categoria[]>(this.getApiCategorias());
  }

  public GetCategoria(id: string): Observable<Categoria> {
    return this.http.get<Categoria>(this.getApiCategorias() + '/' + id);
  }

  public PostCategoria(categoria: Categoria): Observable<string> {
    const headers = new HttpHeaders()
      .set('content-type', 'application/json');
    return this.http.post<string>(this.getApiCategorias(), categoria, { 'headers': headers });
  }

  public PutCategoria(id: string, categoria: Categoria): Observable<any> {
    const headers = new HttpHeaders()
      .set('content-type', 'application/json');
    return this.http.put<any>(this.getApiCategorias() + `/${id}` , categoria, { 'headers': headers });
  }

  public DelCategoria(id: string): Observable<string> {
    const headers = new HttpHeaders()
      .set('content-type', 'application/json');
    return this.http.delete<any>(this.getApiCategorias() + `/${id}`, { 'headers': headers });
  }


  // API de servicios
  // ---------------------------------------------------------------------------
  // ---------------------------------------------------------------------------
  private getApiServicio(): string {
    return `${environment.apiUrl}/api/servicios`;
  }

  public GetServicios(id: string): Observable<Servicio[]> {
    console.log(this.getApiCategorias());
    return this.http.get<Servicio[]>(this.getApiServicio() + '/categoria/' + id );
  }

  public GetServicio(id: string): Observable<Servicio> {
    return this.http.get<Servicio>(this.getApiServicio() + '/' + id);
  }

  public PostServicio(servicio: Servicio): Observable<string> {
    const headers = new HttpHeaders()
      .set('content-type', 'application/json');
    return this.http.post<string>(this.getApiServicio(), servicio, { 'headers': headers });
  }

  public PutServicio(id: string, servicio: Categoria): Observable<any> {
    const headers = new HttpHeaders()
      .set('content-type', 'application/json');
    return this.http.put<any>(this.getApiServicio() + `/${id}` , servicio, { 'headers': headers });
  }

  public DelServicio(id: string): Observable<string> {
    const headers = new HttpHeaders()
      .set('content-type', 'application/json');
    return this.http.delete<any>(this.getApiServicio() + `/${id}`, { 'headers': headers });
  }


  // API de precios
   // ---------------------------------------------------------------------------
  // ---------------------------------------------------------------------------
  private getApiPrecios(): string {
    return `${environment.apiUrl}/api/precios`;
  }

  public GetPrecios(id: string): Observable<Precio[]> {
    return this.http.get<Precio[]>(this.getApiPrecios() + '/servicio/' + id );
  }

  public GetPrecio(id: string): Observable<Precio> {
    return this.http.get<Precio>(this.getApiPrecios() + '/' + id);
  }

  public PostPrecio(precio: Precio): Observable<string> {
    const headers = new HttpHeaders()
      .set('content-type', 'application/json');
    return this.http.post<string>(this.getApiPrecios(), precio, { 'headers': headers });
  }

  public PutPrecio(id: string, precio: Servicio): Observable<any> {
    const headers = new HttpHeaders()
      .set('content-type', 'application/json');
    return this.http.put<any>(this.getApiPrecios() + `/${id}` , precio, { 'headers': headers });
  }

  public DelPrecio(id: string): Observable<string> {
    const headers = new HttpHeaders()
      .set('content-type', 'application/json');
    return this.http.delete<any>(this.getApiPrecios() + `/${id}`, { 'headers': headers });
  }


}
