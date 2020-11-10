import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BaibaoComponent } from './baibao.component';

describe('BaibaoComponent', () => {
  let component: BaibaoComponent;
  let fixture: ComponentFixture<BaibaoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BaibaoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BaibaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
