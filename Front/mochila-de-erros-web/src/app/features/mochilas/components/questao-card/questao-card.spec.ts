import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QuestaoCard } from './questao-card';

describe('QuestaoCard', () => {
  let component: QuestaoCard;
  let fixture: ComponentFixture<QuestaoCard>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [QuestaoCard]
    })
    .compileComponents();

    fixture = TestBed.createComponent(QuestaoCard);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
