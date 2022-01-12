import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FilmeDetailFormComponent } from './filme-detail-form.component';

describe('FilmeDetailFormComponent', () => {
  let component: FilmeDetailFormComponent;
  let fixture: ComponentFixture<FilmeDetailFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FilmeDetailFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FilmeDetailFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
