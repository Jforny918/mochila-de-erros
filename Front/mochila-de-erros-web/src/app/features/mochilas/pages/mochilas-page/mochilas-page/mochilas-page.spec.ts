import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MochilasPage } from './mochilas-page';

describe('MochilasPage', () => {
  let component: MochilasPage;
  let fixture: ComponentFixture<MochilasPage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MochilasPage]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MochilasPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
