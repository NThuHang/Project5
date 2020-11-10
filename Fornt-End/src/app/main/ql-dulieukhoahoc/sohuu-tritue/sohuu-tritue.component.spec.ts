import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SohuuTritueComponent } from './sohuu-tritue.component';

describe('SohuuTritueComponent', () => {
  let component: SohuuTritueComponent;
  let fixture: ComponentFixture<SohuuTritueComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SohuuTritueComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SohuuTritueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
