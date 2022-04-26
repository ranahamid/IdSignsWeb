import {Entity, validatedResource, endpoint} from 'aurelia-orm';

@validatedResource('resend-email')
@endpoint('auth')

export class ResendEmail extends Entity{
}