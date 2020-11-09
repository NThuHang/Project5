import { Component, OnInit, AfterViewInit, Renderer2 } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit,AfterViewInit {
  title = 'FrontEndAngular';
  constructor(private renderer: Renderer2){}
  ngOnInit() {

  }

  ngAfterViewInit() {
    this.loadScripts();
  }

  public loadScripts() {
    this.renderExternalScript('assets/js/vendor/jquery-1.12.4.min.js').onload = () => {
    }
    this.renderExternalScript('assets/js/bootstrap.min.js').onload = () => {
    }
    this.renderExternalScript('assets/js/wow.min.js').onload = () => {
    }
    this.renderExternalScript('assets/js/jquery-price-slider.js').onload = () => {
    }
    this.renderExternalScript('assets/js/jquery.meanmenu.js').onload = () => {
    }
    this.renderExternalScript('assets/js/owl.carousel.min.js').onload = () => {
    }
    this.renderExternalScript('assets/js/jquery.sticky.js').onload = () => {
    }
    this.renderExternalScript('assets/js/jquery.scrollUp.min.js').onload = () => {
    }
    this.renderExternalScript('assets/js/scrollbar/jquery.mCustomScrollbar.concat.min.js').onload = () => {
    }
    this.renderExternalScript('assets/js/scrollbar/mCustomScrollbar-active.js').onload = () => {
    }
    this.renderExternalScript('assets/js/metisMenu/metisMenu.min.js').onload = () => {
    }
    this.renderExternalScript('assets/js/metisMenu/metisMenu-active.js').onload = () => {
    }
    this.renderExternalScript('assets/js/tab.js').onload = () => {
    }
    this.renderExternalScript('assets/js/icheck/icheck.min.js').onload = () => {
    }
    this.renderExternalScript('assets/js/icheck/icheck-active.js').onload = () => {
    }
    this.renderExternalScript('assets/js/plugins.js').onload = () => {
    }
    this.renderExternalScript('assets/js/main.js').onload = () => {
    }
  }

  public renderExternalScript(src: string): HTMLScriptElement {
    const script = document.createElement('script');
    script.type = 'text/javascript';
    script.src = src;
    script.async = true;
    script.defer = true;
    this.renderer.appendChild(document.body, script);
    return script;
  }

}
