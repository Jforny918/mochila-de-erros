import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MochilaCard } from './mochila-card';

describe('MochilaCard', () => {
  let component: MochilaCard;
  let fixture: ComponentFixture<MochilaCard>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MochilaCard]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MochilaCard);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
