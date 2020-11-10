import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QtDaotaoComponent } from './qt-daotao.component';

describe('QtDaotaoComponent', () => {
  let component: QtDaotaoComponent;
  let fixture: ComponentFixture<QtDaotaoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QtDaotaoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QtDaotaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
