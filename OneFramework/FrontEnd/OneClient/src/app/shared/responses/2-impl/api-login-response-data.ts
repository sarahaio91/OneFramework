import { ApiResponseData } from '../1-shared/index';

export class ApiLoginResponseData extends ApiResponseData {
    public RequestAt: string;
    public ExpireIn: number;
    public TokenType: string;
    public Token: string;
}
