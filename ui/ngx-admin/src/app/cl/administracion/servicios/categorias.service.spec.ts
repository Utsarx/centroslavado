import { CategoriasService } from './categorias.service';
import { TestBed } from '@angular/core/testing';

describe('CategoriasService', () => {
  let service: CategoriasService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CategoriasService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
