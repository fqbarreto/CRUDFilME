import { TestBed } from '@angular/core/testing';

import { FilmesDetailService } from './filmes-detail.service';

describe('FilmesDetailService', () => {
  let service: FilmesDetailService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FilmesDetailService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
