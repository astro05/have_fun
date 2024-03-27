import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MongoDbLogServiceComponent } from './mongoDbLogService.component';

describe('MongoDbLogServiceComponent', () => {
  let component: MongoDbLogServiceComponent;
  let fixture: ComponentFixture<MongoDbLogServiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MongoDbLogServiceComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MongoDbLogServiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
