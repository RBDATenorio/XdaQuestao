import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QuestaoHeaderComponent } from './questao-header.component';

describe('QuestaoHeaderComponent', () => {
  let component: QuestaoHeaderComponent;
  let fixture: ComponentFixture<QuestaoHeaderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QuestaoHeaderComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QuestaoHeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
