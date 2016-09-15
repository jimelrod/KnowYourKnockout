export class App {
  configureRouter(config, router) {
    config.title = 'Aurelia';
    config.map([
      { route: ['', 'welcome'], name: 'welcome',      moduleId: 'welcome',      nav: true, title: 'Welcome' },
      { route: 'users',         name: 'users',        moduleId: 'users',        nav: true, title: 'Github Users' },
      { route: 'login',         name: 'login',        moduleId: 'login',        nav: true, title: 'Login' },
      { route: 'testing',       name: 'testing',      moduleId: 'testing',      nav: true, title: 'Testing' }
    ]);

    this.router = router;
  }
}
