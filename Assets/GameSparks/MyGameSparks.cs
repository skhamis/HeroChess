using System;
using System.Collections.Generic;
using GameSparks.Core;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;

//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!
//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!
//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!

namespace GameSparks.Api.Requests{
	public class LogEventRequest_SAVE_PLAYER : GSTypedRequest<LogEventRequest_SAVE_PLAYER, LogEventResponse>
	{
	
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogEventResponse (response);
		}
		
		public LogEventRequest_SAVE_PLAYER() : base("LogEventRequest"){
			request.AddString("eventKey", "SAVE_PLAYER");
		}
		public LogEventRequest_SAVE_PLAYER Set_EXP( long value )
		{
			request.AddNumber("EXP", value);
			return this;
		}			
		
		public LogEventRequest_SAVE_PLAYER Set_POS( string value )
		{
			request.AddString("POS", value);
			return this;
		}
		public LogEventRequest_SAVE_PLAYER Set_GOLD( long value )
		{
			request.AddNumber("GOLD", value);
			return this;
		}			
	}
	
	public class LogChallengeEventRequest_SAVE_PLAYER : GSTypedRequest<LogChallengeEventRequest_SAVE_PLAYER, LogChallengeEventResponse>
	{
		public LogChallengeEventRequest_SAVE_PLAYER() : base("LogChallengeEventRequest"){
			request.AddString("eventKey", "SAVE_PLAYER");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogChallengeEventResponse (response);
		}
		
		/// <summary>
		/// The challenge ID instance to target
		/// </summary>
		public LogChallengeEventRequest_SAVE_PLAYER SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		public LogChallengeEventRequest_SAVE_PLAYER Set_EXP( long value )
		{
			request.AddNumber("EXP", value);
			return this;
		}			
		public LogChallengeEventRequest_SAVE_PLAYER Set_POS( string value )
		{
			request.AddString("POS", value);
			return this;
		}
		public LogChallengeEventRequest_SAVE_PLAYER Set_GOLD( long value )
		{
			request.AddNumber("GOLD", value);
			return this;
		}			
	}
	
}
	

namespace GameSparks.Api.Messages {


}
