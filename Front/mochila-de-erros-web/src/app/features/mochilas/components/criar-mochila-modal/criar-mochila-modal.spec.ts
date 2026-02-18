import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CriarMochilaModal } from './criar-mochila-modal';

describe('CriarMochilaModal', () => {
  let component: CriarMochilaModal;
  let fixture: ComponentFixture<CriarMochilaModal>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CriarMochilaModal]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CriarMochilaModal);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
