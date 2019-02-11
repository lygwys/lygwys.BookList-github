import { AppComponentBase } from '@shared/component-base/app-component-base';
import {
  Component,
  OnInit,
  ViewChild,
  Output,
  EventEmitter,
  Injector,
} from '@angular/core';
import { NzSelectComponent } from 'ng-zorro-antd';

@Component({
  selector: 'app-booktag-nzselect',
  templateUrl: './booktag-nzselect.component.html',
  styles: [],
})
export class BooktagNzselectComponent extends AppComponentBase
  implements OnInit {
  @ViewChild('select') select: NzSelectComponent;

  @Output()
  selectedDataChange = new EventEmitter();

  constructor(injector: Injector) {
    super(injector);
  }

  listOfOption = [];
  listOfTagOptions = [];

  ngOnInit(): void {}
}
