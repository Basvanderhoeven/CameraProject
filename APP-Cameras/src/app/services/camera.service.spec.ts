import { TestBed, inject } from '@angular/core/testing';

import { CameraService } from './camera.service';

describe('MovieService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CameraService]
    });
  });

  it('should be created', inject([CameraService], (service: CameraService) => {
    expect(service).toBeTruthy();
  }));
});
