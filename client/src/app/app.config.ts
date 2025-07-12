import {
  ApplicationConfig,
  provideAppInitializer,
  provideExperimentalZonelessChangeDetection,
} from '@angular/core'
import { provideRouter } from '@angular/router'

import { provideHttpClient, withFetch } from '@angular/common/http'
import {
  provideClientHydration,
  withEventReplay,
} from '@angular/platform-browser'
import { routes } from './app.routes'
import { configurationInitializer } from './core/configuration/configuration.initializer'

export const appConfig: ApplicationConfig = {
  providers: [
    provideExperimentalZonelessChangeDetection(),
    provideRouter(routes),
    provideHttpClient(withFetch()),
    provideClientHydration(withEventReplay()),
    provideAppInitializer(configurationInitializer('/api/config')),
  ],
}
