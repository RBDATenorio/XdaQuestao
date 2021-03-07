/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { QuestaoService } from './questao.service';

describe('Service: Questao', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [QuestaoService]
    });
  });

  it('should ...', inject([QuestaoService], (service: QuestaoService) => {
    expect(service).toBeTruthy();
  }));
});
