import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QtCongtacComponent } from './qt-congtac.component';

describe('QtCongtacComponent', () => {
  let component: QtCongtacComponent;
  let fixture: ComponentFixture<QtCongtacComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QtCongtacComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QtCongtacComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
