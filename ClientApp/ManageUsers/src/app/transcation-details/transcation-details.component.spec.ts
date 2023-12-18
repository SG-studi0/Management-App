import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TranscationDetailsComponent } from './transcation-details.component';

describe('TranscationDetailsComponent', () => {
  let component: TranscationDetailsComponent;
  let fixture: ComponentFixture<TranscationDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TranscationDetailsComponent]
    });
    fixture = TestBed.createComponent(TranscationDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
