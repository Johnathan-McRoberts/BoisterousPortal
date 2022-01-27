import { Component, OnInit, Output, EventEmitter } from '@angular/core';

export class NavigationMenuItem {
  public link: string | any;
  public text: string | any;
  public icon: string | any;
}

@Component({
  selector: 'app-side-navigation-list',
  templateUrl: './side-navigation-list.component.html',
  styleUrls: ['./side-navigation-list.component.scss']
})
export class SideNavigationListComponent implements OnInit {

  @Output() sideNavClose = new EventEmitter();

  @Output() selectedMenuItem = new EventEmitter<string>();

  public navigationMenuItems: NavigationMenuItem[] =
    [
      //{
      //  link: "/user-login", text: "User Login", icon: "lock_open"
      //},
      //{
      //  link: "/tables", text: "Tables", icon: "table_chart"
      //},
      //{
      //  link: "/charts", text: "Charts", icon: "timeline"
      //},
      //{
      //  link: "/forms", text: "Forms", icon: "library_add"
      //},
      //{
      //  link: "/import-export", text: "Import/Export", icon: "import_export"
      //},
      //{
      //    link: "/to-do", text: "To Do List", icon: "list_alt"
      //},
      {
        link: "/fetch-data", text: "Fetch weather", icon: "list_alt"
      },

      {
        link: "/fetch", text: "Fetch better weather", icon: "import_export"
      },

      {
        link: "/templates-list", text: "Templates", icon: "design_services"
      },

      {
        link: "/reports-list", text: "Reports", icon: "post_add"
      }

      
      //,
      //{
      //  link: "/home", text: "Home", icon: "home"
      //}
    ];

  public static defaultMenuItemText: string = "User Login";

  constructor() { }

  ngOnInit(): void {
  }

  public onSideNavClose = (param: any) => {
    console.log("closed using :" + param);
    this.sideNavClose.emit();
    this.selectedMenuItem.emit(param.toString());
  };
}
