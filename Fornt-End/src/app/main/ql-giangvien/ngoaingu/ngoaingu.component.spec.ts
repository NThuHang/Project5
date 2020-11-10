import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NgoainguComponent } from './ngoaingu.component';

describe('NgoainguComponent', () => {
  let component: NgoainguComponent;
  let fixture: ComponentFixture<NgoainguComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NgoainguComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NgoainguComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
