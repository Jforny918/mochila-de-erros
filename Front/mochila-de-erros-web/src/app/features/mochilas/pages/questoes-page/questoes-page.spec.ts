import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QuestoesPage } from './questoes-page';

describe('QuestoesPage', () => {
  let component: QuestoesPage;
  let fixture: ComponentFixture<QuestoesPage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [QuestoesPage]
    })
    .compileComponents();

    fixture = TestBed.createComponent(QuestoesPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
