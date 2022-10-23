import { AbstractControl,  ValidationErrors } from "@angular/forms";

export class CustomValidators {
    static passwordsMatching(control: AbstractControl): ValidationErrors | null {
        const password = control.get('password')?.value;
        const confirmPassword = control.get('confirmPassword')?.value;

        if ((password === confirmPassword) && (password !== null && confirmPassword !== null)) {
          return null;
        } else {
          return { passwordsNotMatching: true };
        }
      }
}
