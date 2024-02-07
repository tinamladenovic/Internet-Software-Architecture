import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompanyadminHomepageComponent } from './companyadmin-homepage.component';

describe('CompanyadminHomepageComponent', () => {
  let component: CompanyadminHomepageComponent;
  let fixture: ComponentFixture<CompanyadminHomepageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CompanyadminHomepageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CompanyadminHomepageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
