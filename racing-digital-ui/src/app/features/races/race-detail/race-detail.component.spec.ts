import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RaceDetailComponent } from './race-detail.component';

describe('RaceDetailComponent', () => {
  let component: RaceDetailComponent;
  let fixture: ComponentFixture<RaceDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RaceDetailComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RaceDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
