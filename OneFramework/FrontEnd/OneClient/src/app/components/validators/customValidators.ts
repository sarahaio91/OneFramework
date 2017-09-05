import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';

export declare class CustomValidator extends Validators {
    static confirmPassword(control: AbstractControl): ValidationErrors | null;
}