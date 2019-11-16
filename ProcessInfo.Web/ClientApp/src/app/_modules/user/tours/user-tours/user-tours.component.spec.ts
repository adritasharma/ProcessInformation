/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { UserToursComponent } from './user-tours.component';

describe('UserToursComponent', () => {
  let component: UserToursComponent;
  let fixture: ComponentFixture<UserToursComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserToursComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserToursComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
