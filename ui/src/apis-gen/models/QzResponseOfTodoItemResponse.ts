/* tslint:disable */
/* eslint-disable */
/**
 * 轻舟 RestAPI
 * An ASP.NET Core Web API for managing ToDo items
 *
 * The version of the OpenAPI document: v1
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */

import { mapValues } from '../runtime';
import type { ErrorCode } from './ErrorCode';
import {
    ErrorCodeFromJSON,
    ErrorCodeFromJSONTyped,
    ErrorCodeToJSON,
} from './ErrorCode';
import type { QzResponseOfTodoItemResponseData } from './QzResponseOfTodoItemResponseData';
import {
    QzResponseOfTodoItemResponseDataFromJSON,
    QzResponseOfTodoItemResponseDataFromJSONTyped,
    QzResponseOfTodoItemResponseDataToJSON,
} from './QzResponseOfTodoItemResponseData';

/**
 * 
 * @export
 * @interface QzResponseOfTodoItemResponse
 */
export interface QzResponseOfTodoItemResponse {
    /**
     * 
     * @type {boolean}
     * @memberof QzResponseOfTodoItemResponse
     */
    success?: boolean;
    /**
     * 
     * @type {ErrorCode}
     * @memberof QzResponseOfTodoItemResponse
     */
    code?: ErrorCode;
    /**
     * 
     * @type {QzResponseOfTodoItemResponseData}
     * @memberof QzResponseOfTodoItemResponse
     */
    data?: QzResponseOfTodoItemResponseData;
    /**
     * 
     * @type {string}
     * @memberof QzResponseOfTodoItemResponse
     */
    message?: string;
    /**
     * 
     * @type {number}
     * @memberof QzResponseOfTodoItemResponse
     */
    message1?: number;
    /**
     * 
     * @type {string}
     * @memberof QzResponseOfTodoItemResponse
     */
    traceId?: string;
}

/**
 * Check if a given object implements the QzResponseOfTodoItemResponse interface.
 */
export function instanceOfQzResponseOfTodoItemResponse(value: object): boolean {
    return true;
}

export function QzResponseOfTodoItemResponseFromJSON(json: any): QzResponseOfTodoItemResponse {
    return QzResponseOfTodoItemResponseFromJSONTyped(json, false);
}

export function QzResponseOfTodoItemResponseFromJSONTyped(json: any, ignoreDiscriminator: boolean): QzResponseOfTodoItemResponse {
    if (json == null) {
        return json;
    }
    return {
        
        'success': json['success'] == null ? undefined : json['success'],
        'code': json['code'] == null ? undefined : ErrorCodeFromJSON(json['code']),
        'data': json['data'] == null ? undefined : QzResponseOfTodoItemResponseDataFromJSON(json['data']),
        'message': json['message'] == null ? undefined : json['message'],
        'message1': json['message1'] == null ? undefined : json['message1'],
        'traceId': json['traceId'] == null ? undefined : json['traceId'],
    };
}

export function QzResponseOfTodoItemResponseToJSON(value?: QzResponseOfTodoItemResponse | null): any {
    if (value == null) {
        return value;
    }
    return {
        
        'success': value['success'],
        'code': ErrorCodeToJSON(value['code']),
        'data': QzResponseOfTodoItemResponseDataToJSON(value['data']),
        'message': value['message'],
        'message1': value['message1'],
        'traceId': value['traceId'],
    };
}

