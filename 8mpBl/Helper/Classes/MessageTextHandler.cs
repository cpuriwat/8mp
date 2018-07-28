using System;
using System.Collections.Generic;
using System.Diagnostics;
using _8mpBl.Enums;
using _8mpBl.Helper.Interfaces;
using _8mpBl.Model.General;

namespace _8mpBl.Helper.Classes
{
    public class MessageTextHandler : IMessageTextHandler
    {
        private readonly ReturnMsgVm _msg;
        private readonly ReturnMsgVm _msgSystem;
        private readonly List<ReturnMsgVm> _msgList;
        private bool _systemCommunicationErrorFound; // handle communication error then upper class return object nothing error
        public MessageTextHandler()
        {
            _msg = new ReturnMsgVm();
            _msgSystem = new ReturnMsgVm();
            _msgList = new List<ReturnMsgVm>();
        }
        public void ClearSystemCommunicationError()
        {
            _msgSystem.ReturnMsgEnum = 0;
            _msgSystem.ReturnMsg = "";
        }
        public ReturnMsgVm GetSystemMsg(EnumMessage errCode)
        {
            return GetSystemMsg(errCode, "");
        }
        public ReturnMsgVm GetSystemMsg(EnumMessage eCode, string value)
        {
            _msg.ReturnMsgEnum = eCode;
            var eCodeValue = (int)eCode;
            switch (eCodeValue.ToString().Substring(0, 1))
            {
                case "9":
                    {
                        _msg.ReturnMsg = GetErrMsg(eCode, value);
                        break;
                    }

                case "8":
                    {
                        _msg.ReturnMsg = GetErrMsg(eCode, value);
                        break;
                    }

                case "5":
                    {
                        _msg.ReturnMsg = GetMsg(eCode, value);
                        break;
                    }

                case "2":
                    {
                        _msg.ReturnMsg = GetMsg(eCode, value);
                        break;
                    }

                case "1":
                    {
                        _msg.ReturnMsg = GetMsg(eCode, value);
                        break;
                    }

                case "0":
                    {
                        _msgSystem.ReturnMsgEnum = eCode;
                        _msgSystem.ReturnMsg = GetErrMsg(eCode, value);
                        _systemCommunicationErrorFound = true;
                        break;
                    }

                default:
                    {
                        break;
                    }
            }
            if (_systemCommunicationErrorFound)
            {
            }
            _msgList.Add(_msg);
            Console.WriteLine(_msg.ReturnMsg);
            return _msg;
        }
        public ReturnMsgVm GetSystemMsg(EnumMessage eCode, List<string> value)
        {
            _msg.ReturnMsgEnum = eCode;
            var eCodeValue = (int)eCode;
            switch (eCodeValue.ToString().Substring(0, 1))
            {
                case "9":
                    {
                        _msg.ReturnMsg = GetFullMsg(eCode, value);
                        break;
                    }

                case "5":
                    {
                        _msg.ReturnMsg = GetFullMsg(eCode, value);
                        break;
                    }

                case "2":
                    {
                        _msg.ReturnMsg = GetFullMsg(eCode, value);
                        break;
                    }

                case "1":
                    {
                        _msg.ReturnMsg = GetFullMsg(eCode, value);
                        break;
                    }

                case "0":
                    {
                        _msgSystem.ReturnMsgEnum = eCode;
                        _msgSystem.ReturnMsg = GetFullMsg(eCode, value);
                        _systemCommunicationErrorFound = true;
                        break;
                    }

                default:
                    {
                        break;
                    }
            }

            if (eCodeValue.ToString().Substring(0, 1) == "9")
                _msg.ReturnMsg = GetFullMsg(eCode, value);
            Console.WriteLine(_msg.ReturnMsg);
            _msgList.Add(_msg);
            Debug.Print(_msg.ReturnMsg);
            return _msg;
        }
        private string GetMsg(EnumMessage eCode, string value)
        {
            switch (eCode)
            {
                case EnumMessage.PleaseFillInUsernameAndPassword:
                    {
                        return "Please fill in username and password to login to system.";
                    }

                case EnumMessage.LoginSuccess:
                    {
                        return "Login success. Loading module.";
                    }

                case EnumMessage.ConnectingToServer:
                    {
                        return "Connecting to server.";
                    }

                case EnumMessage.UnitIsAbort:
                    {
                        return "Abort this operation.";
                    }

                case EnumMessage.Welcome:
                    {
                        return "Welcome " + value + ".";
                    }

                case EnumMessage.DisplayUserName:
                    {
                        return "Username : " + value;
                    }

                case EnumMessage.TransactionSuccess:
                    {
                        return "Transation on unit " + value + " success.";
                    }

                case EnumMessage.TransactionParamSuccess:
                    {
                        return "Transation on unit parametric " + value + " success.";
                    }

                case EnumMessage.TransactionPerformSuccess:
                    {
                        return "Transation on unit perform " + value + " success.";
                    }

                case EnumMessage.SL_FomMainTitle:
                    {
                        return "MP - Manufacturing Platform";
                    }

                case EnumMessage.SL_StatusOnline:
                    {
                        return "Status : Online";
                    }

                default:
                    {
                        return "";
                    }
            }
        }
        private string GetErrMsg(EnumMessage eCode, string value)
        {
            switch (eCode)
            {
                case EnumMessage.ElementIsEmpty:
                    {
                        return "Please fill in " + value + ".";
                    }

                case EnumMessage.NotFoundSn:
                    {
                        return value + " not found in the system.";
                    }

                case EnumMessage.HostUrlNotFound:
                    {
                        return "Web Service not found.";
                    }

                case EnumMessage.LoginFail:
                    {
                        return "Login failed or cannot be proceed.";
                    }

                case EnumMessage.RequestUnauthorized:
                    {
                        return "Request is unauthorized to access the data.";
                    }

                case EnumMessage.AdditionalLicenseRequired:
                    {
                        return "Sorry. This feature is unavailable. Please contact your system administrator";
                    }

                case EnumMessage.SystemNoOperationAssign:
                    {
                        return "System Error : No operation assign to serial number object. ";
                    }

                case EnumMessage.SystemObjectIsNothing:
                    {
                        return "System Code Error : Object is nothing found. ";
                    }

                case EnumMessage.TransactionParamFail:
                    {
                        return "Transation on unit parametric " + value + " failed.";
                    }

                case EnumMessage.TransactionFail:
                    {
                        return "Transation on unit " + value + " failed.";
                    }

                case EnumMessage.TransactionPerformFail:
                    {
                        return "Transation on unit perform " + value + " failed.";
                    }

                default:
                    {
                        return "";
                    }
            }
        }
        private string GetFullMsg(EnumMessage eCode, List<string> value)
        {
            switch (eCode)
            {
                case EnumMessage.SnFormatNotMatch:
                    {
                        if (value.Count >= 2) return value[0] + " is wrong format. Value  must be in " + value[1] + ".";
                        break;
                    }

                case EnumMessage.OperationNotFoundInRoute:
                    {
                        if (value.Count >= 2) return value[0] + " doesn't have operation " + value[1] + ".";
                        break;
                    }

                case EnumMessage.SystemObjectNotFoundBySlug:
                    {
                        if (value.Count >= 2) return value[0] + " cannot retrive detail by slug " + value[1] + ".";
                        break;
                    }

                case EnumMessage.WrongOperation:
                    {
                        if (value.Count >= 2) return value[0] + " is wrong operation. Unit is waiting operation " + value[1];
                        break;
                    }

                case EnumMessage.SnNotFound:
                    {
                        if (value.Count >= 1) return value[0] + " is not found in system.";
                        break;
                    }

                case EnumMessage.SnIsInWip:
                    {
                        if (value.Count >= 1) return value[0] + " is still in process in system.";
                        break;
                    }

                case EnumMessage.ParameterItemDetailNotFound:
                    {
                        if (value.Count >= 1) return "Parameter " + value[0] + " cannot find detail information in system.";
                        break;
                    }

                case EnumMessage.ValueSelected:
                    {
                        if (value.Count >= 1) return value[0] + " is selected.";
                        break;
                    }

                case EnumMessage.UnitIsReady:
                    {
                        if (value.Count >= 1) return "Unit SN : " + value[0] + " is ready for this operation.";
                        break;
                    }

                case EnumMessage.SnNotInWip:
                    {
                        if (value.Count >= 1) return value[0] + " is not WIP in system.";
                        break;
                    }

                case EnumMessage.WorkOrderNotFound:
                    {
                        if (value.Count >= 1) return "Work order " + value[0] + " is not found in system.";
                        break;
                    }

                case EnumMessage.SnDetailNotFound:
                    {
                        if (value.Count >= 1) return "System cannot find information detail for " + value[0];
                        break;
                    }
                case EnumMessage.RouteNotFound:
                    {
                        if (value.Count >= 1) return "System cannot find route for " + value[0];
                        break;
                    }
                case EnumMessage.SnipReturnFalse:
                    {
                        if (value.Count >= 3) return "Reject on " + value[0] + " -- " + value[1] + Environment.NewLine + value[2] + ".";
                        break;
                    }
                case EnumMessage.HookFail:
                    {
                        if (value.Count >= 2) return "Validation Failed on Snip Name : " + value[0] + " -- " + value[1] + ".";
                        break;
                    }
                case EnumMessage.NextCodeExecute:
                    {
                        if (value.Count >= 5) return "Next operation is changed by nextcode : " + value[1] + " -- " + value[3] + " to " + value[4];
                        break;
                    }
                default:
                    {
                        return "";
                    }

            }

            return "";
        }
        public void Dispose()
        {
        }
    }
}
