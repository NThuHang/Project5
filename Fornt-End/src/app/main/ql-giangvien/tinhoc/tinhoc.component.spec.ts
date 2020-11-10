import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TinhocComponent } from './tinhoc.component';

describe('TinhocComponent', () => {
  let component: TinhocComponent;
  let fixture: ComponentFixture<TinhocComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TinhocComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TinhocComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
