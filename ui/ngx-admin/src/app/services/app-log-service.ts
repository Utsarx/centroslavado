import { Injectable } from "@angular/core";
import { NbGlobalLogicalPosition, NbToastrService } from "@nebular/theme";

@Injectable({
    providedIn: 'root',
  })
export class AppLogService {

    constructor(private toastrService: NbToastrService) { }

    Informacion(titulo: string, mensaje: string): void {
        if (mensaje) this.showToast(titulo, mensaje, 'info-outline');
      }
    
      Exito(titulo: string, mensaje: string): void {
        if (mensaje) this.showToast(titulo, mensaje, 'checkmark-circle-2-outline');
      }
    
      Advertencia(titulo: string, mensaje: string): void {
        if (mensaje) this.showToast(titulo, mensaje, 'alert-circle-outline');
      }
    
      Falla(titulo: string, mensaje: string): void {
          if (mensaje) this.showToast(titulo, mensaje, 'close-circle-outline');
      }
    
      private showToast(t: string, m: string, i: string) {
        this.toastrService.show(
          `${t}`,
          `${m}`,
          { icon: i , iconPack: 'eva',	limit: 3,
          position: NbGlobalLogicalPosition.BOTTOM_END, preventDuplicates: false });
      }
}