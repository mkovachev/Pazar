import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-pop-up',
  templateUrl: './pop-up.component.html',
  styleUrls: ['./pop-up.component.css'],
  animations: []
})
export class PopUpComponent implements OnInit {
  @Input() isOpen = false;

  constructor() { }

  ngOnInit(): void {
  }

}
