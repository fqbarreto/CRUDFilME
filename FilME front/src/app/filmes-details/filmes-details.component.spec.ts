import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FilmesDetailsComponent } from './filmes-details.component';

describe('FilmesDetailsComponent', () => {
  let component: FilmesDetailsComponent;
  let fixture: ComponentFixture<FilmesDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FilmesDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FilmesDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
