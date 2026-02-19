import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CriarQuestaoModal } from './criar-questao-modal';

describe('CriarQuestaoModal', () => {
  let component: CriarQuestaoModal;
  let fixture: ComponentFixture<CriarQuestaoModal>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CriarQuestaoModal]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CriarQuestaoModal);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
